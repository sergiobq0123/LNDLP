import { enviroment } from "src/enviroments/enviroment"


export class Urls {
  static BASE = enviroment.url
  static AUTH = '/api/Auth'
  static USER = '/api/User'
  static LOGIN = '/Login'
  static REGISTER = '/Register'
  static USERROLE = '/api/UserRole'
  static ARTIST = '/api/Artist'
  static EMAIL = '/api/Email'
  static FESTIVAL = '/api/Event/type/Festival'
  static CONCIERTO = '/api/Event/type/Concierto'
  static SOCIALNETWORK = '/api/SocialNetwork'
  static EVENT = '/api/Event'
  static EVENTTYPE = '/api/EventType'
  static CREW = '/api/Crew'
  static DOSSIER = '/api/Dossier'
  static IMAGE = '/postImage'
}
