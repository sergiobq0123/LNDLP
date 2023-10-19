import { Artist } from 'src/app/models/artist.model';
import { Festival } from 'src/app/models/festival.model';

export interface FestivalArtistDialogData{
  festival: Festival,
  artistas: Artist[],
}
