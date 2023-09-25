import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingWebComponent } from './marketing-web.component';

describe('MarketingWebComponent', () => {
  let component: MarketingWebComponent;
  let fixture: ComponentFixture<MarketingWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MarketingWebComponent]
    });
    fixture = TestBed.createComponent(MarketingWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
