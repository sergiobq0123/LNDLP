import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoutubeVideoVisualComponent } from './youtube-video-visual.component';

describe('YoutubeVideoVisualComponent', () => {
  let component: YoutubeVideoVisualComponent;
  let fixture: ComponentFixture<YoutubeVideoVisualComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [YoutubeVideoVisualComponent]
    });
    fixture = TestBed.createComponent(YoutubeVideoVisualComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
