import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtistaSellosWebComponent } from './artista-sellos-web.component';

describe('ArtistaSellosWebComponent', () => {
  let component: ArtistaSellosWebComponent;
  let fixture: ComponentFixture<ArtistaSellosWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArtistaSellosWebComponent]
    });
    fixture = TestBed.createComponent(ArtistaSellosWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
