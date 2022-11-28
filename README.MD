# Ryokan API

## Setup
The files in this repo are the ones that I created/edited. This means that if you wanted to make this work on your end, you'd need to install the relevant packages.


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
