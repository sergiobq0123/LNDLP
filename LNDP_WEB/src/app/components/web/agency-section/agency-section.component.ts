import { Component } from '@angular/core';
import { CompanyService } from 'src/app/services/intranet/company.service';

@Component({
  selector: 'app-agency-section',
  templateUrl: './agency-section.component.html',
  styleUrls: ['./agency-section.component.scss']
})
export class AgencySectionComponent {
  title = "AGENCY"
  description = "Conectamos con tu público objetivo y hacemos crecer tu proyecto mejorando el posicionamiento. Aportamos visibilidad, presencia y calidad a tu proyecto para hacerlo más profesional. Nos introducimos en las redes sociales para que tu proyecto maximice su visibilidad. Trabajamos con diferentes marcas que puedan encajar con tu proyecto"

}
