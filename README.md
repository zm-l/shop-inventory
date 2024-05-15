# Kyberlife Interview (C#)

## Overview
This is a RESTful API that follows a simplified version of Robert Martin's
"Clean Architecture".

## Requirements
- .NET Core 8.0

## Database
The database is a simple in-memory database with no persistence, so no
database setup is required.

## Architecture
As per the Clean Architecture, the project is divided into layers. There are
four, being

1. Domain
2. Service
3. Core
4. Infrastructure

The **Domain** layer contains the business entities. In this application, there is
a single entity, `ShopItem` that represents an item sold in a shop. All other
layers depend on this entity.

The **Service** layer contains the client-facing API. It defines the high-level
actions that a client might want to perform. There is a single service located
in `Service/ShopItemController.cs`.

The **Core** layer contains the Use Cases, which are units of business logic.
Some examples are "add an item to the shop" or "get all items from the shop".

The **Infrastructure** layer contains the implementation details. In this case,
most of the details are retrieving and storing data in the database.

The flow of control flows from the Service, to the Core, to the Infrastructure,
which then unwinds back through the layers to the Service layer. Data is
passed through each layer in via _Data Transfer Objects_ (DTOs), which are
the various `Request` and `Response` classes.

## Task
Your task is to implement **2** endpoints in `Service/ShopItemController.cs`.
The specifications are as follows:

```
ShopItem {
  id: int
  name: string
  price: decimal
  quantity: int
}

BaseResponse<T> {
  success: HttpStatus
  errors: string[]
  data: T
}

GET /api/shop-item/{id}
- Description: Gets a single item from the shop.
    - If id does not exist, returns 404 with a suitable error message.
    - Otherwise, returns 200 with the item.
- Request: { id: int }
- Response: BaseResponse<ShopItem>

POST /api/shop-item/{id?:int}
- Description: Adds a new item to the shop. id is optional.
    - If id is not given, the item is added to the shop with a new
      id marked as unsold, returning 200
    - If id is given and the item does not exist, returns 404 with a suitable
      error message.
    - If id is given and the item exists and the item is sold, returns 400
      with a suitable error message.
    - If id is given and the item exists and the item is unsold, updates the
      item, leaving it as unsold, and returns 200.
- Request: ShopItem
- Response: BaseResponse<int>
```

If time permits, you may implement the following endpoint:

```
GET /api/shop-item/revenue
- Description: Gets the total revenue of all sold items in the shop.
    - Returns 200 with the total revenue.
- Request: {}
- Response: BaseResponse<decimal>
```

There is a single endpoint already implemented `GET /api/shop-items` which
retrieves all the items in the shop.