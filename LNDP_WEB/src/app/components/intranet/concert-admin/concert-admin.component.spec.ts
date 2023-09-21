import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConcertAdminComponent } from './concert-admin.component';

describe('ConcertAdminComponent', () => {
  let component: ConcertAdminComponent;
  let fixture: ComponentFixture<ConcertAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ConcertAdminComponent]
    });
    fixture = TestBed.createComponent(ConcertAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
