Summary

Test summary: total: 8, failed: 4, succeeded: 4, skipped: 0, duration: 9.2s
Test Cases Execution Details

Test Case ID	Test Name	Status	Execution Time (ms)	Remarks
1	GetPost_ShouldReturnPostDetails	✅ Pass	250 ms	Valid post retrieved successfully.
2	GetPost_InvalidId_ShouldReturnNotFound	✅ Pass	220 ms	Invalid ID returned 404 Not Found.
3	CreatePost_ShouldReturnCreatedPost	✅ Pass	270 ms	Post created with status code 201.
4	CreatePost_MissingTitle_ShouldReturnBadRequest	❌ Fail	300 ms	 Expected: not equal to Created But was:  Created
5	UpdatePost_ShouldReturnUpdatedPost	✅ Pass	260 ms	Post updated successfully with status code 200.
6	UpdatePost_InvalidId_ShouldReturnNotFound	❌ Fail		240 ms	Expected: NotFound But was:InternalServerError
7	DeletePost_ShouldReturnSuccessStatusCode	❌ Fail		230 ms	Expected: 0 But was:  2
8	DeletePost_InvalidId_ShouldReturnNotFound	❌ Fail		210 ms	 Expected: NotFound But was:  OK


