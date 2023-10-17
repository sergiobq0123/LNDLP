import { Artist } from "./artist.model";
import { ModelBase } from "./model-base.model";

export interface Festival extends ModelBase {
  name?: string,
  city?: string,
  location?: string,
  urlLocation?: string,
  tickets?: string
  artists?: Artist[]
}
