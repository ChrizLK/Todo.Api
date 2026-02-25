
EndPoints


1./api/TodoItems - Get All
2./api/TodoItems - Post
3./api/TodoItems/{id} - Get by Id
4./api/TodoItems/{id} - Put
5./api/TodoItems/{id} - Delete



Test Cases


1.Get All

https://localhost:7131/api/TodoItems?pageNumber=1

Response Body

{
  "items": [
    {
      "id": 3,
      "title": "Task 2",
      "description": "2nd Task description",
      "isCompleted": false,
      "createdAt": "2026-02-25T19:36:21.0845985"
    },
    {
      "id": 2,
      "title": "Edited Assignment",
      "description": "no desc",
      "isCompleted": true,
      "createdAt": "2026-02-25T18:54:43.4430172"
    }
  ],
  "totalCount": 2,
  "pageNumber": 1,
  "pageSize": 10
}


Post

https://localhost:7131/api/


{
  "title": "Task 2",
  "description": "2nd Task description" 
}

Response : 201 Created


3.Get by Id

https://localhost:7131/api/TodoItems/3'

{
  "id": 3,
  "title": "Task 2",
  "description": "2nd Task description",
  "isCompleted": false,
  "createdAt": "2026-02-25T19:36:21.0845985"
}


4.Update /Put

https://localhost:7131/api/TodoItems/2

{
  "title": "task Edited",
  "description": "Desc Updated",
  "isCompleted": true
}

Updated successfully.


5.Delete


https://localhost:7131/api/TodoItems/3

Deleted successfully.


