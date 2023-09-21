import { Component} from '@angular/core';
import { DossierService } from 'src/app/services/intranet/dossier.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  imagenUrl: string = '../../../assets/homePage.png';
}
