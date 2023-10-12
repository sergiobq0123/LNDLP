import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingSellosComponent } from './marketing-sellos.component';

describe('MarketingSellosComponent', () => {
  let component: MarketingSellosComponent;
  let fixture: ComponentFixture<MarketingSellosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MarketingSellosComponent]
    });
    fixture = TestBed.createComponent(MarketingSellosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
