# Clean App API

- [Clean App API](#clean-app-api)
    - [Auth](#auth)
	- [Register](#register)
    	- [Register Request](#register-request)
    	- [Register Responce](#register-responce)
	- [Login](#login)
    	- [Login Request](#login-request)
    	- [Login Responce](#login-responce)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register request

```json
{
	"firstName": "Amichai",
	"lastName": "Mantinband",
	"email": "email@axample.com",
	"password": "Pa$$w0rd"
}
```
#### Register responce

```js
200 OK
```

```json
{
	"id": "9282F008-F46B-4807-A97E-28B8225AEC2E",
	"firstName": "Amichai",
	"lastName": "Mantinband",
	"email": "email@axample.com",
	"token": "fhejHdf..fd34"
}
```
### Login

```js
POST {{host}}/auth/login
```

#### Lign request

```json
{
	"email": "email@axample.com",
	"password": "Pa$$w0rd"
}
```
#### Login responce

```js
200 OK
```

```json
{
	"id": "9282F008-F46B-4807-A97E-28B8225AEC2E",
	"firstName": "Amichai",
	"lastName": "Mantinband",
	"email": "email@axample.com",
	"token": "fhejHdf..fd34"
}
```


