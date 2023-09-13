import { enviroment } from "src/enviroments/enviroment"


export class Urls {
  static BASE = enviroment.url
  static LOGIN = '/api/Auth/login'
  static USER = '/api/User'
  static ARTIST = '/api/Artist'
  static FESTIVAL = '/api/Event/type/Festival'
  static CONCIERTO = '/api/Event/type/Concierto'
  static SOCIALNETWORK = '/api/SocialNetwork'
  static EVENT = '/api/Event'
  static EVENTTYPE = '/api/EventType'
}
