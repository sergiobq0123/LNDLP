import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeSectionComponent } from './home-section/home-section.component';
import { AgencySectionComponent } from './agency-section/agency-section.component';
import { MarketingSectionComponent } from './marketing-section/marketing-section.component';
import { TourManagerSectionComponent } from './tour-manager-section/tour-manager-section.component';
import { VisualSectionComponent } from './visual-section/visual-section.component';
import { ArtistDetailAlbumsComponent } from './artist-detail-section/artist-detail-albums/artist-detail-albums.component';
import { ArtistDetailSectionComponent } from './artist-detail-section/artist-detail-section.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: HomeSectionComponent,
        children: [
          {
            path: '',
            loadChildren: () =>
              import('./home-section/home-section.module').then(
                (m) => m.HomeSectionModule
              ),
          },
        ],
      },
      {
        path: 'Marketing',
        component: MarketingSectionComponent,
        children: [
          {
            path: '',
            loadChildren: () =>
              import('./marketing-section/marketing-section.module').then(
                (m) => m.MarketingSectionModule
              ),
          },
        ],
      },
      {
        path: 'Agency',
        component: AgencySectionComponent,
        children: [
          {
            path: '',
            loadChildren: () =>
              import('./agency-section/agency-section.module').then(
                (m) => m.AgencySectionModule
              ),
          },
        ],
      },
      {
        path: 'Visual',
        component: VisualSectionComponent,
        children: [
          {
            path: '',
            loadChildren: () =>
              import('./visual-section/visual-section.module').then(
                (m) => m.VisualSectionModule
              ),
          },
        ],
      },
      {
        path: 'Tourmanager',
        component: TourManagerSectionComponent,
        children: [
          {
            path: '',
            loadChildren: () =>
              import('./tour-manager-section/tour-manager-section.module').then(
                (m) => m.TourManagerSectionModule
              ),
          },
        ],
      },
      {
        path: 'Artist/:id',
        component: ArtistDetailSectionComponent,
        children: [
          {
            path: '',
            loadChildren: () =>
              import(
                './artist-detail-section/artist-detail-section.module'
              ).then((m) => m.ArtistDetailSectionModule),
          },
        ],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WebRoutingModule {}
