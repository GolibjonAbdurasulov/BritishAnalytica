Documentation
method | route | auth | description

Authentication

POST /Auth/Login | common  |  Login method
query{}
body{
  "email": "string",
  "password": "string"
}

POST /Auth/LogOut | Token  |  LogOut method
query{}
body{
  "email": "string",
  "username": "string"
}

GET /Auth/GetToken | common  |  Get token
query{}
body{}



