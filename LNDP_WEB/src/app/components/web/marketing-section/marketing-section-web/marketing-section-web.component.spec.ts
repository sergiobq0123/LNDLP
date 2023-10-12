import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingSectionWebComponent } from './marketing-section-web.component';

describe('MarketingSectionWebComponent', () => {
  let component: MarketingSectionWebComponent;
  let fixture: ComponentFixture<MarketingSectionWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MarketingSectionWebComponent]
    });
    fixture = TestBed.createComponent(MarketingSectionWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
