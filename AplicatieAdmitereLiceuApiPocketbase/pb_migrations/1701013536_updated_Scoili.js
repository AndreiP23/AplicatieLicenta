/// <reference path="../pb_data/types.d.ts" />
migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("y8a6hmeefhvr8b5")

  collection.name = "Scoli"

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("y8a6hmeefhvr8b5")

  collection.name = "Scoili"

  return dao.saveCollection(collection)
})
