# Shizuka Sushi API

- [Shizuka Sushi API](#shizuka-sushi-api)
  - [Create Dish](#create-dish)
    - [Create Dish Request](#create-dish-request)
    - [Create Dish Response](#create-dish-response)
  - [Get Dish](#get-dish)
    - [Get Dish Request](#get-dish-request)
    - [Get Dish Response](#get-dish-response)
  - [Update Dish](#update-dish)
    - [Update Dish Request](#update-dish-request)
    - [Update Dish Response](#update-dish-response)
  - [Delete Dish](#delete-dish)
    - [Delete Dish Request](#delete-dish-request)
    - [Delete Dish Response](#delete-dish-response)

## Create Dish

### Create Dish Request

```js
POST /dishes
```

```json
{
    "name": "California Roll",
    "description": "Popular sushi dish featuring imitation crab, avocado, and cucumber, rolled inside-out with rice on the outside, sprinkled with toasted sesame seeds.",
    "ingredients": [
        "Crab",
        "Avocado",
        "Cucumber",
        "Sesame seeds"
    ]
}
```

### Create Dish Response

```js
201 Created
```

```yml
Location: {{host}}/Dishes/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "California Roll",
    "description": "Popular sushi dish featuring imitation crab, avocado, and cucumber, rolled inside-out with rice on the outside, sprinkled with toasted sesame seeds.",
    "lastModifiedDateTime": "2023-04-06T12:00:00",
    "ingredients": [
        "Crab",
        "Avocado",
        "Cucumber",
        "Sesame seeds"
    ]
}
```

## Get Dish

### Get Dish Request

```js
GET /dishes/{{id}}
```

### Get Dish Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "California Roll",
    "description": "Popular sushi dish featuring imitation crab, avocado, and cucumber, rolled inside-out with rice on the outside, sprinkled with toasted sesame seeds.",
    "lastModifiedDateTime": "2023-04-06T12:00:00",
    "ingredients": [
        "Crab",
        "Avocado",
        "Cucumber",
        "Sesame seeds"
    ]
}
```

## Update Dish

### Update Dish Request

```js
PUT /dishes/{{id}}
```

```json
{
    "name": "California Roll",
    "description": "Popular sushi dish featuring imitation crab, avocado, and cucumber, rolled inside-out with rice on the outside, sprinkled with toasted sesame seeds.",
    "ingredients": [
        "Crab",
        "Avocado",
        "Cucumber",
        "Sesame seeds"
    ]
}
```

### Update Dish Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/dishes/{{id}}
```

## Delete Dish

### Delete Dish Request

```js
DELETE /dishes/{{id}}
```

### Delete Dish Response

```js
204 No Content
```