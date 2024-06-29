/// <reference path="../pb_data/types.d.ts" />
migrate((db) => {
  const collection = new Collection({
    "id": "5xauys6e64vn8rg",
    "created": "2024-05-18 12:14:24.755Z",
    "updated": "2024-05-18 12:14:24.755Z",
    "name": "TESTusers",
    "type": "base",
    "system": false,
    "schema": [
      {
        "system": false,
        "id": "ixmuatag",
        "name": "name",
        "type": "text",
        "required": false,
        "presentable": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null,
          "pattern": ""
        }
      },
      {
        "system": false,
        "id": "n9vvawvs",
        "name": "password",
        "type": "text",
        "required": false,
        "presentable": false,
        "unique": false,
        "options": {
          "min": null,
          "max": null,
          "pattern": ""
        }
      }
    ],
    "indexes": [],
    "listRule": null,
    "viewRule": null,
    "createRule": null,
    "updateRule": null,
    "deleteRule": null,
    "options": {}
  });

  return Dao(db).saveCollection(collection);
}, (db) => {
  const dao = new Dao(db);
  const collection = dao.findCollectionByNameOrId("5xauys6e64vn8rg");

  return dao.deleteCollection(collection);
})
