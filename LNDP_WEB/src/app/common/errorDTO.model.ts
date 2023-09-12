export enum ErrorCode {
  NotDefined = 0,
  IncorrectPassword = 1,
  UserNotFound = 2,
  FormNotValid = 3,
}
export enum ErrorType {
  NotDefined = 0,
  Login = 1,
  FormValidators = 2
}

export interface ErrorDTO {
  code?: ErrorCode;
  type?: ErrorType;
  description?: string;
}
