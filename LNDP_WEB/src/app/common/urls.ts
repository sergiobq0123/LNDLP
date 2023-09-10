import { enviroment } from "src/enviroments/enviroment"


export class Urls {
  static BASE = enviroment.url
  static LOGIN = '/api/Auth/login'
  static USER = '/api/user'
}
