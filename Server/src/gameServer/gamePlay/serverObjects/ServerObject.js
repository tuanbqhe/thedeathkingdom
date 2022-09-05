const shortID = require("shortid");
const Vector2 = require("../../../dto/Vector2");

module.exports = class ServerObject {
  constructor() {
    this.id = shortID.generate();
    this.name = "ServerObject";
    this.position = new Vector2();
  }
};
