cmake_minimum_required(VERSION 3.18)
project(psychic-octo-guide LANGUAGES C CXX)

# Set reasonable defaults
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)

# Output directories (optional)
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR})
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR})
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR})

# --- Source discovery ---
# Prefer module-specific sources in PCMod/src, then fallback to src/ or top-level .cpp files.
file(GLOB_RECURSE MOXXIE_SOURCES
  "${CMAKE_CURRENT_SOURCE_DIR}/PCMod/src/*.c"
  "${CMAKE_CURRENT_SOURCE_DIR}/PCMod/src/*.cc"
  "${CMAKE_CURRENT_SOURCE_DIR}/PCMod/src/*.cpp"
  "${CMAKE_CURRENT_SOURCE_DIR}/PCMod/src/*.cxx"
)

if(NOT MOXXIE_SOURCES)
  # fallback locations
  file(GLOB_RECURSE MOXXIE_SOURCES
    "${CMAKE_CURRENT_SOURCE_DIR}/src/*.c"
    "${CMAKE_CURRENT_SOURCE_DIR}/src/*.cc"
    "${CMAKE_CURRENT_SOURCE_DIR}/src/*.cpp"
    "${CMAKE_CURRENT_SOURCE_DIR}/src/*.cxx"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.c"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.cc"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.cpp"
    "${CMAKE_CURRENT_SOURCE_DIR}/*.cxx"
  )
endif()

# If still empty, emit a helpful fatal error that lists what was found nearby.
if(NOT MOXXIE_SOURCES)
  # try to list anything .cpp/.c near top level for diagnostic purposes
  file(GLOB_RECURSE ALL_POTENTIAL_SRCS
    "${CMAKE_CURRENT_SOURCE_DIR}/**/*.c"
    "${CMAKE_CURRENT_SOURCE_DIR}/**/*.cc"
    "${CMAKE_CURRENT_SOURCE_DIR}/**/*.cpp"
    "${CMAKE_CURRENT_SOURCE_DIR}/**/*.cxx"
  )
  message(STATUS "Diagnostic: No sources were found for the 'moxxie' library.")
  if(ALL_POTENTIAL_SRCS)
    string(REPLACE ";" "\n  " FOUND_LIST "${ALL_POTENTIAL_SRCS}")
    message(FATAL_ERROR
      "No sources matched PCMod/src or src/ patterns. \n"
      "Expected to find files like PCMod/src/*.cpp (or put source filenames into the add_library call). \n\n"
      "Files that WERE found under the project (for your review):\n  ${FOUND_LIST}\n\n"
      "Fix options:\n"
      " - move your .cpp files into PCMod/src/ or src/ OR\n"
      " - modify this CMakeLists.txt add_library() call to list the correct source files explicitly.\n"
    )
  else()
    message(FATAL_ERROR
      "No C/C++ source files found anywhere under the project. \n"
      "Add your implementation .cpp files (e.g. PCMod/src/moxxie.cpp) or adjust this CMakeLists to point to the correct sources."
    )
  endif()
endif()

# --- Create the library (target name WITHOUT leading 'lib') ---
add_library(moxxie SHARED ${MOXXIE_SOURCES})

# Example include dirs (adjust to match your repo layout)
# If your headers live under PCMod/include or include/
if(EXISTS "${CMAKE_CURRENT_SOURCE_DIR}/PCMod/include")
  target_include_directories(moxxie PUBLIC "${CMAKE_CURRENT_SOURCE_DIR}/PCMod/include")
elseif(EXISTS "${CMAKE_CURRENT_SOURCE_DIR}/include")
  target_include_directories(moxxie PUBLIC "${CMAKE_CURRENT_SOURCE_DIR}/include")
endif()

# Compile options (optional)
target_compile_features(moxxie PUBLIC cxx_std_17)
target_compile_options(moxxie PRIVATE
  $<$<CXX_COMPILER_ID:GNU,Clang>:-Wall;-Wextra;-Wpedantic>
)

# Optional versioning
set_target_properties(moxxie PROPERTIES VERSION 1.0.0 SOVERSION 1)

# Install rules (optional)
install(TARGETS moxxie
  LIBRARY DESTINATION lib
  ARCHIVE DESTINATION lib
  RUNTIME DESTINATION bin
)
