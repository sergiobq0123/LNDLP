import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FestivalCrewComponent } from './festival-crew.component';

describe('FestivalCrewComponent', () => {
  let component: FestivalCrewComponent;
  let fixture: ComponentFixture<FestivalCrewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FestivalCrewComponent]
    });
    fixture = TestBed.createComponent(FestivalCrewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
