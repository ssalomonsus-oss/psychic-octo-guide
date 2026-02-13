cmake_minimum_required(VERSION 3.10)
project(moxxie)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_C_STANDARD 11)

add_library(moxxie SHARED moxxie.cpp)

find_library(log-lib log)

target_link_libraries(moxxie ${log-lib})

set_target_properties(moxxie PROPERTIES OUTPUT_NAME "libmoxxie")
