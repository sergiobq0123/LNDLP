import { ModelBase } from "./model-base.model";

export interface Artist extends ModelBase{
  name ?: string;
  city?: string;
  photo?:string;
  recruitmentEmail ?: string;
  communicationEmail ?: string;
  phone ?: string;
}
