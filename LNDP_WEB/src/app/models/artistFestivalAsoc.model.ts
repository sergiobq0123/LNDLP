import { Artist } from "./artist.model";
import { Festival } from "./festival.model";
import { ModelBase } from "./model-base.model";

export interface ArtistFestivalAsoc extends ModelBase {
  artistas : Artist []
  festivales : Festival[]
  artistId: number
  festivalId : number
}
