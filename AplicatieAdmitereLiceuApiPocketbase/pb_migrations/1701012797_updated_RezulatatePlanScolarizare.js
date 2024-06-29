/// <reference path="../pb_data/types.d.ts" />
migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("6664uc9putm8c0t")

  // add
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "jnv3ieoe",
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
  const collection = dao.findCollectionByNameOrId("6664uc9putm8c0t")

  // remove
  collection.schema.removeField("jnv3ieoe")

  return dao.saveCollection(collection)
})
