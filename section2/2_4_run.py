import os
import json

from library import *

def add(num1, num2):
    return num1 + num2

input_numbers_string = os.environ['req_query_nums']
print("Read in string of {}".format(input_numbers_string))

input_numbers = map(int, input_numbers_string.split(","))
print("Read in a list of ints as {}".format(input_numbers))

local_sum = add(input_numbers[0], input_numbers[1])
lib_sum = lib_add(input_numbers[0], input_numbers[1])

print("The sum of {} is {} (local) {} (lib)".format(input_numbers,
    local_sum, lib_sum))


body_response = {
    "inputs": input_numbers_string,
    "local_sum": local_sum,
    "lib_sum": lib_sum
}

response = {
    "status": 200,
    "body": body_response,
    "headers": {
        "x-header": "some-value",
        "x-header-2": "other value"
    }
}

output = open(os.environ['res'], 'w')
output.write(json.dumps(response))
