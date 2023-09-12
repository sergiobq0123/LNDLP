import { ModelBase } from './model-base.model';

export interface User extends ModelBase {
  username: string;
  email: string;
  password: string;
}
