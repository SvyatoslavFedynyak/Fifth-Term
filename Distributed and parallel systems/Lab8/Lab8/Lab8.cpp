#include <iostream>
#include <thread>
#include <ctime>
#define CL_USE_DEPRECATED_OPENCL_2_0_APIS
#include <CL/cl.h>

using namespace std;

void simple_sum_matrix(int** first_matrix, int** second_matrix, int** sum_matrix_result, size_t size,
	size_t index_column = 0, size_t threads_step = 1)
{
	for (size_t i = 0; i < size; ++i)
	{
		for (size_t j = index_column; j < size; j += threads_step)
		{
			sum_matrix_result[i][j] = first_matrix[i][j] + second_matrix[i][j];
		}
	}
}

void parallel_sum_matrix(int** first_matrix, int** second_matrix, int** sum_matrix_result, size_t size, size_t threads_amount = 1)
{
	thread* thread_arr = new thread[threads_amount];
	for (size_t i = 0; i < threads_amount; ++i)
	{
		thread_arr[i] = thread(simple_sum_matrix, first_matrix, second_matrix, sum_matrix_result, size, i, threads_amount);
	}
	for (size_t i = 0; i < threads_amount; ++i)
	{
		thread_arr[i].join();
	}
}

void sum_matrix_OpenCL(int* first_matrix, int* second_matrix, int* sum_matrix_result, size_t size)
{
	const char *source_code =
		"__kernel void OpenCLAddingMatrix(__global int* a, __global int* b, __global int* result, const int quantity) \n"\
		"{ \n"\
		"int index = get_global_id(0); \n"\
		"result[index] = a[index] + b[index];"\
		"} \n\n";


	cl_platform_id platform_id;
	cl_device_id device_id;
	cl_uint num_platforms;
	cl_uint num_devices;

	if (clGetPlatformIDs(1, &platform_id, &num_platforms) != CL_SUCCESS)
	{
		cout << "Unable to get platform id" << endl;
	}

	// CL_DEVICE_TYPE_GPU - All calculations will be on GPU.
	if (clGetDeviceIDs(platform_id, CL_DEVICE_TYPE_GPU, 1, &device_id, &num_devices) != CL_SUCCESS)
	{
		cout << "Unable to get device id" << endl;
	}

	cl_context_properties properties[3];
	properties[0] = CL_CONTEXT_PLATFORM;
	properties[1] = (cl_context_properties)platform_id;
	properties[2] = 0;

	cl_int err;
	cl_context context = clCreateContext(properties, 1, &device_id, NULL, NULL, &err);
	cl_command_queue commandQueue = clCreateCommandQueue(context, device_id, 0, &err);
	cl_program program = clCreateProgramWithSource(context, 1, (const char **)&source_code, NULL, &err);

	if (clBuildProgram(program, 0, NULL, NULL, NULL, NULL) != CL_SUCCESS)
	{
		printf("Error building program\n");
	}

	cl_kernel kernel = clCreateKernel(program, "OpenCLAddingMatrix", &err);

	cl_mem first_matrix_buffer = clCreateBuffer(context, CL_MEM_READ_WRITE, sizeof(int) * size * size, NULL, NULL);
	cl_mem second_matrix_buffer = clCreateBuffer(context, CL_MEM_READ_WRITE, sizeof(int) * size * size, NULL, NULL);
	cl_mem third_matrix_buffer = clCreateBuffer(context, CL_MEM_READ_WRITE, sizeof(int) * size * size, NULL, NULL);

	clEnqueueWriteBuffer(commandQueue, first_matrix_buffer, CL_TRUE, 0, sizeof(int) * size * size, first_matrix, 0, NULL, NULL);
	clEnqueueWriteBuffer(commandQueue, second_matrix_buffer, CL_TRUE, 0, sizeof(int) * size * size, second_matrix, 0, NULL, NULL);
	clEnqueueWriteBuffer(commandQueue, third_matrix_buffer, CL_TRUE, 0, sizeof(int) * size * size, sum_matrix_result, 0, NULL, NULL);

	size_t arraySize = size * size;
	clSetKernelArg(kernel, 0, sizeof(cl_mem), &first_matrix_buffer);
	clSetKernelArg(kernel, 1, sizeof(cl_mem), &second_matrix_buffer);
	clSetKernelArg(kernel, 2, sizeof(cl_mem), &third_matrix_buffer);
	clSetKernelArg(kernel, 3, sizeof(int), &arraySize);

	cl_uint work_dim = 1;
	size_t global_work_offset = 0;
	size_t global_work_size = size * size;
	size_t local_work_size = size;

	clock_t begin_time = clock();
	clEnqueueNDRangeKernel(commandQueue, kernel, work_dim, NULL, &global_work_size, &local_work_size, 0, NULL, NULL);

	clEnqueueReadBuffer(commandQueue, third_matrix_buffer, CL_TRUE, 0, sizeof(int) *size * size, sum_matrix_result, 0, NULL, NULL);
	cout << endl << "OpenCL sum matrices time: " << ((float)(clock() - begin_time)) / CLOCKS_PER_SEC << " s" << endl;

	clReleaseMemObject(first_matrix_buffer);
	clReleaseMemObject(second_matrix_buffer);
	clReleaseMemObject(third_matrix_buffer);

	clReleaseKernel(kernel);
	clReleaseCommandQueue(commandQueue);
	clReleaseProgram(program);
	clReleaseContext(context);
}

void show_matrix(int** matrix, size_t size)
{
	for (size_t i = 0; i < size; ++i)
	{
		for (size_t j = 0; j < size; ++j)
		{
			cout << matrix[i][j] << "\t";
		}
		cout << endl;
	}
	cout << endl;
}

void main()
{
	size_t size;
	cout << "Input size of matrices: ";
	cin >> size;

	size_t threads_amount;
	cout << "Input amount of threads: ";
	cin >> threads_amount;

	int** first_matrix = new int*[size];
	int** second_matrix = new int*[size];

	int** sum_matrix_result = new int*[size];
	int** parallel_sum_matrix_result = new int*[size];
	int** opencl_sum_matrix_result = new int*[size];

	srand(time(NULL));

	for (size_t i = 0; i < size; ++i)
	{
		first_matrix[i] = new int[size];
		second_matrix[i] = new int[size];

		sum_matrix_result[i] = new int[size];
		parallel_sum_matrix_result[i] = new int[size];
		opencl_sum_matrix_result[i] = new int[size];
		for (size_t j = 0; j < size; ++j)
		{
			first_matrix[i][j] = rand() % 100;
			second_matrix[i][j] = rand() % 100;
		}
	}

	//cout << endl << "First matrix: " << endl;
	//show_matrix(first_matrix, size);
	//cout << "Second matrix: " << endl;
	//show_matrix(second_matrix, size);


	clock_t begin_time = clock();
	simple_sum_matrix(first_matrix, second_matrix, sum_matrix_result, size);
	cout << endl << "Simple sum matrices time: " << (float)(clock() - begin_time) / CLOCKS_PER_SEC << "s" << endl;

	//cout << "Simple sum matrices: " << endl;
	//show_matrix(sum_matrix_result, size);


	begin_time = clock();
	parallel_sum_matrix(first_matrix, second_matrix, parallel_sum_matrix_result, size, threads_amount);
	cout << endl << "Parallel sum matrices time: " << (float)(clock() - begin_time) / CLOCKS_PER_SEC << "s" << endl;

	//cout << "Parallel sum matrices: " << endl;
	//show_matrix(parallel_sum_matrix_result, size);


	// All matrices transform to one-dimensional arrays with size = row_size*columns_size,
	// because GPU (Graphics Proccesing Unit) computes such arrays the best.

	int* a_matrix = new int[size*size]; // first_matrix
	int* b_matrix = new int[size*size]; // second_matrix
	int* res_matrix = new int[size*size]; // result_matrix

	int counter = 0;
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			a_matrix[counter] = first_matrix[i][j];
			b_matrix[counter] = second_matrix[i][j];
			res_matrix[counter] = 0;
			++counter;
		}
	}

	sum_matrix_OpenCL(a_matrix, b_matrix, res_matrix, size);

	for (size_t i = 0; i < size; ++i)
	{
		for (size_t j = 0; j < size; ++j)
		{
			opencl_sum_matrix_result[i][j] = res_matrix[i*size + j];
		}
	}

	//cout << "OpenCL sum matrices: " << endl;
	//show_matrix(opencl_sum_matrix_result, size);

	delete[] a_matrix;
	delete[] b_matrix;
	delete[] res_matrix;
	for (size_t i = 0; i < size; ++i)
	{
		delete[] first_matrix[i];
		delete[] second_matrix[i];

		delete[] sum_matrix_result[i];
		delete[] parallel_sum_matrix_result[i];
		delete[] opencl_sum_matrix_result[i];
	}

	system("pause");
}

