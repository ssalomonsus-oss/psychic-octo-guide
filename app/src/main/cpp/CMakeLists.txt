cmake_minimum_required(VERSION 3.10)
project(libmoxxie)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_C_STANDARD 11)

add_library(libmoxxie SHARED libmoxxie.cpp)

find_library(log-lib log)

target_link_libraries(libmoxxie ${log-lib})

set_target_properties(libmoxxie PROPERTIES OUTPUT_NAME "libmoxxie")
