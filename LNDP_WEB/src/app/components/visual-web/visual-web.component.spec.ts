import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualWebComponent } from './visual-web.component';

describe('VisualWebComponent', () => {
  let component: VisualWebComponent;
  let fixture: ComponentFixture<VisualWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VisualWebComponent]
    });
    fixture = TestBed.createComponent(VisualWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
