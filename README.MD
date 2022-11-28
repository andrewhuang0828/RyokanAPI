# Ryokan API

## Setup
The files in this repo are the ones that I created/edited. This means that if you want to make this work on your end, you'll probably need the proper dependencies.

![alt text](https://github.com/andrewhuang0828/RyokanAPI/blob/main/API%20dependencies.png)


## Routes

### Get Requests
GET ```http://localhost:3402/api/prefecture/{Optional Id}```

Returns a list of all prefectures in the database if an Id is not provided. If an Id is provided, it will return the prefecture with the associated Id. If the provided Id does not exist, it will return an error saying "That prefecture doesn't exist!"

Sample GET request without an Id 
GET ```http://localhost:3402/api/prefecture```
```
[
    {
        "prefectureId": 6,
        "prefecture": "Gunma"
    },
    {
        "prefectureId": 1,
        "prefecture": "Kanagawa"
    },
    {
        "prefectureId": 4,
        "prefecture": "Kyoto"
    },
    {
        "prefectureId": 7,
        "prefecture": "Miyagi"
    },
    {
        "prefectureId": 2,
        "prefecture": "Nagano"
    },
    {
        "prefectureId": 5,
        "prefecture": "Osaka"
    },
    {
        "prefectureId": 8,
        "prefecture": "Yamagata"
    }
]
```

GET ```http://localhost:3402/api/ryokan/{Optional Id}```

Returns a list of all prefectures in the database if an id is not provided. If an Id is provided, it will return the prefecture with the associated Id. If the provided Id does not exist, it will return an error saying "That ryokan doesn't exist!"

Sample GET request without an Id
GET ```http://localhost:3402/api/ryokan```
```
[
    {
        "ryokanId": 1,
        "ryokan_name": "Hakone Suishoen",
        "prefecture": "Kanagawa",
        "has_onsen": true,
        "half_board": true
    },
    {
        "ryokanId": 3,
        "ryokan_name": "Yumotokan",
        "prefecture": "Kyoto",
        "has_onsen": true,
        "half_board": true
    },
    {
        "ryokanId": 6,
        "ryokan_name": "Notoraku",
        "prefecture": "Osaka",
        "has_onsen": true,
        "half_board": true
    }
]
```

### Post Requests
POST ```http://localhost:3402/api/prefecture```

Sending a POST request to the prefecture endpoint will add a new entry to the prefecture database as long you have provided the valid fields in the request body.

Example POST request and request body
POST ```http://localhost:3402/api/prefecture```

With a request body of
```
{
    "prefecture" : "Akita"
}
```
Which should return
```
{
    "prefectureId": 11,
    "prefecture": "Akita"
}
```

POST ```http://localhost:3402/api/ryokan```

Sending a POST request to the ryokan endpoint will add a new entry to the prefecture database as long you have provided the valid fields in the request body. Note that the prefecture field must be an entry that exists within the prefecture database, otherwise, you will not be able to add the ryokan entry.

Example POST request and request body
POST ```http://localhost:3402/api/ryokan```

With a request body of
```
{
    "ryokan_name": "Umi to Irishi no Yado Teisui",
    "prefecture": "Akita",
    "has_onsen": true,
    "half_board": true
}
```
Which should return
```
{
    "ryokanId": 7,
    "ryokan_name": "Umi to Irishi no Yado Teisui",
    "prefecture": "Akita",
    "has_onsen": true,
    "half_board": true
}
```
### Delete Requests
DELETE ```http://localhost:3402/api/prefecture{Id}```

DELETE ```http://localhost:3402/api/ryokan{Id}```

Deleting an entry in either database is possible by specifying the Id of the entry. When trying to delete an entry from the prefecture database, if there are any entries that exist with that prefecture in the prefecture field in the ryokan database, you will be unable to delete the prefecture entry.

Example DELETE Request

DELETE ```http://localhost:3402/api/prefecture/1```
which should return ```Successful deletion!```

Example DELETE Request

DELETE ```http://localhost:3402/api/ryokan/1```
which should return ```Successful deletion!```

If the endpoint is provided with an Id of an nonexistant entry, it wll return ```That prefecture/ryokan doesn't exist!``` depending on whether it was the the prefecture or ryokan endpoint.


