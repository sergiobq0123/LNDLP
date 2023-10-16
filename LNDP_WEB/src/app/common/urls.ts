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
  static CONCIERTO = '/api/Concert'
  static SOCIALNETWORK = '/api/SocialNetwork'
  static EVENT = '/api/Event'
  static EVENTTYPE = '/api/EventType'
  static SONG = '/api/Song'
  static ALBUM = '/api/Album'
  static RECORD = '/api/Record'
  static BRAND = '/api/Brand'
  static COLLABORATION = '/api/Collaboration'
  static COMPANY = '/api/Company'
  static YOUTUBEVIDEO = '/api/YoutubeVideo'
  static COMPANYTYPE = '/api/CompanyType'
  static IMAGE = '/postImage'
  static INTRANET = '/intranet'
  static KEYS = '/keys'
}
