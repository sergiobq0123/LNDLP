import { Artist } from "./artist.model";
import { Festival } from "./festival.model";
import { ModelBase } from "./model-base.model";

export interface ArtistFestivalAsoc extends ModelBase {
  artist : Artist []
  festival : Festival[]
  artistId: number
  festivalId : number
}
