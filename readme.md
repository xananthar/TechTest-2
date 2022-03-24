Tech Test
=========

# Overview 

The test consists of two projects:

- TechTest - the main project.
- TechTest.Tests - the unit test project (using xUnit).

# Tasks

1. Write code in `StringStatsProcessor` to populate the `StringStatsModel` model.  
   **Note: for the purposes of this test, a word includes punctuation. "I'm" is a single word and "that." is five characters long (including the full-stop).**
    

2. Create unit tests in the `StringStatsProcessorTests` class to prove that the code written above is correct.
          

3. Add a project and code to the solution to fulfil the following requirement:
   > GIVEN a text string  
   > WHEN it is sent to a HTTP API endpoint  
   > THEN JSON representing the populated StringStatsModel is returned  
   
   Ensure that you can test this via your preferred method (Postman, integration test or webpage, etc)  
  

4. (Optional / for bonus points) Write a fifth unit test which tests very large input to the StringStatsProcessor.Run(string) method.