import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SocialNetwokAdminComponent } from './social-netwok-admin.component';

describe('SocialNetwokAdminComponent', () => {
  let component: SocialNetwokAdminComponent;
  let fixture: ComponentFixture<SocialNetwokAdminComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SocialNetwokAdminComponent]
    });
    fixture = TestBed.createComponent(SocialNetwokAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
