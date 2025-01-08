JsonPlaceholder API Test Project

This project is a RESTful API Testing Framework built using C#, NUnit, and RestSharp. 

Features

GET Request - Validates fetching a post.
POST Request - Tests creating a new post.
PUT Request - Tests updating an existing post.
DELETE Request - Tests deleting a post.
Implements NUnit for test assertions and validations.
Uses RestSharp for HTTP request handling.

Test Cases

1. GET Request: Fetch Post Details
Test:

Fetches post with ID = 1.
Verifies response status code is 200.
Validates post details such as userId, id, title, and body.
2. POST Request: Create a New Post
Test:

Sends a POST request to create a new post.
Validates response status code is 201 (Created).
Confirms response contains new post details.
3. PUT Request: Update a Post
Test:

Updates post with ID = 1.
Checks response status code is 200.
Verifies updated post content.
4. DELETE Request: Delete a Post
Test:

Deletes post with ID = 1.
Ensures status code is 200 or 204 (No Content).

This project is licensed under the MIT License. See the LICENSE file for details.

Let me know if you'd like me to refine or add more details to this README! 😊