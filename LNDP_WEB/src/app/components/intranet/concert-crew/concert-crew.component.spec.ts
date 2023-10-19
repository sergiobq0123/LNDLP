import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConcertCrewComponent } from './concert-crew.component';

describe('ConcertCrewComponent', () => {
  let component: ConcertCrewComponent;
  let fixture: ComponentFixture<ConcertCrewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ConcertCrewComponent]
    });
    fixture = TestBed.createComponent(ConcertCrewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
