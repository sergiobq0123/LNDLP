import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketingSectionComponent } from './marketing-section.component';

describe('MarketingSectionComponent', () => {
  let component: MarketingSectionComponent;
  let fixture: ComponentFixture<MarketingSectionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MarketingSectionComponent]
    });
    fixture = TestBed.createComponent(MarketingSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
