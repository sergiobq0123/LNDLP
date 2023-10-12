import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MarketingSectionWebComponent } from './marketing-section/marketing-section-web/marketing-section-web.component';
import { AgencySectionWebComponent } from './agency-section/agency-section-web/agency-section-web.component';
import { VisualSectionWebComponent } from './visual-section/visual-section-web/visual-section-web.component';
import { TourManagerSectionWebComponent } from './tour-manager-section/tour-manager-section-web/tour-manager-section-web.component';
import { ArtistDetailSectionWebComponent } from './artist-detail-section/artist-detail-section-web/artist-detail-section-web.component';
import { HomeSectionWebComponent } from './home-section/home-section-web/home-section-web.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: HomeSectionWebComponent,
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
        component: MarketingSectionWebComponent,
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
        component: AgencySectionWebComponent,
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
        component: VisualSectionWebComponent,
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
        component: TourManagerSectionWebComponent,
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
        component: ArtistDetailSectionWebComponent,
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
