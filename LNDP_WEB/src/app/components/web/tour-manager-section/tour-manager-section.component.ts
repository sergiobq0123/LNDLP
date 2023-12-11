import { Component } from '@angular/core';
import { ConcertService } from 'src/app/services/intranet/concert.service';

@Component({
  selector: 'app-tour-manager-section',
  templateUrl: './tour-manager-section.component.html',
  styleUrls: ['./tour-manager-section.component.scss'],
})
export class TourManagerSectionComponent {
  title = 'Tour Manager';
  description =
    'Los Tour Managers son los encargados de que cada detalle se ajuste en el escenario. Desde la planificación meticulosa hasta la solución de problemas de último momento, aseguran que todo fluya sin problemas. Su capacidad para resolver desafíos bajo presión y mantener la calma en situaciones caóticas es esencial. Trabajando con artistas, técnicos y organizadores, aseguran la coordinación perfecta de cada aspecto. Además de la organización, los Tour Managers permiten que los artistas se enfoquen en su música. Velan por la seguridad y el bienestar, creando un ambiente propicio para la creatividad y el rendimiento. Cada presentación exitosa no solo fortalece la reputación del artista, sino que también construye conexiones emocionales con la audiencia. Los Tour Managers son los arquitectos de estas relaciones, dejando una impresión duradera.';
}
