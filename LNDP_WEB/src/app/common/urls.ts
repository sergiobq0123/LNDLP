import { enviroment } from "src/enviroments/enviroment"


export class Urls {
  static BASE = enviroment.url
  static CHECKACCES = '/api/Auth/Login'
  static LOGIN = '/login'
}
