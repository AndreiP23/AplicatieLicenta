/// <reference path="../pb_data/types.d.ts" />
migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("gvvu8qoo3hfgt1f")

  // add
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "rxk0psyh",
    "name": "AN",
    "type": "date",
    "required": false,
    "presentable": false,
    "unique": false,
    "options": {
      "min": "",
      "max": ""
    }
  }))

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("gvvu8qoo3hfgt1f")

  // remove
  collection.schema.removeField("rxk0psyh")

  return dao.saveCollection(collection)
})
