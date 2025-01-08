Summary

Total Tests	Passed	Failed	Skipped
8	8	0	0
Test Cases Execution Details

Test Case ID	Test Name	Status	Execution Time (ms)	Remarks
1	GetPost_ShouldReturnPostDetails	✅ Pass	250 ms	Valid post retrieved successfully.
2	GetPost_InvalidId_ShouldReturnNotFound	✅ Pass	220 ms	Invalid ID returned 404 Not Found.
3	CreatePost_ShouldReturnCreatedPost	✅ Pass	270 ms	Post created with status code 201.
4	CreatePost_MissingTitle_ShouldReturnBadRequest	✅ Pass	300 ms	Missing field prevented successful creation.
5	UpdatePost_ShouldReturnUpdatedPost	✅ Pass	260 ms	Post updated successfully with status code 200.
6	UpdatePost_InvalidId_ShouldReturnNotFound	✅ Pass	240 ms	Invalid ID returned 404 Not Found.
7	DeletePost_ShouldReturnSuccessStatusCode	✅ Pass	230 ms	Post deleted successfully.
8	DeletePost_InvalidId_ShouldReturnNotFound	✅ Pass	210 ms	Invalid ID returned 404 Not Found.
