use crate::camera::CameraPlugin;
use crate::inspector::InspectorPlugin;
use crate::scene::ScenePlugin;
use bevy::prelude::*;
use bevy_mod_picking::*;

mod camera;
mod inspector;
mod scene;

fn main() {
    App::new()
        // make sure to add any config resources first, before Bevy:
        .insert_resource(WindowDescriptor {
            title: "Resume Office".to_string(),
            ..Default::default()
        })
        .insert_resource(AmbientLight {
            color: Color::WHITE,
            brightness: 1.0 / 5.0f32,
        })
        // Bevy itself:
        .add_plugins(DefaultPlugins)
        .add_plugins(DefaultPickingPlugins)
        .add_plugin(InspectorPlugin)
        .add_plugin(CameraPlugin)
        .add_plugin(ScenePlugin)
        // resources:
        // events:
        // systems to run once at startup:
        // systems to run each frame:
        // launch the app!
        .run();
}
