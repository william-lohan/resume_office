use bevy::prelude::*;
use bevy_mod_picking::*;

const CAMERA_X: f32 = -0.1;
const CAMERA_Y: f32 = 1.2;
const CAMERA_Z: f32 = 1.1;

fn setup_camera(mut commands: Commands) {
    commands.spawn_bundle(PerspectiveCameraBundle {
        transform: Transform::from_xyz(CAMERA_X, CAMERA_Y, CAMERA_Z)
            .looking_at(Vec3::new(0.0, 0.8, 0.1), Vec3::Y),
        perspective_projection: PerspectiveProjection {
            fov: 0.45,
            ..default()
        },
        ..default()
    }).insert_bundle(PickingCameraBundle::default());
}

const RANGE_VALUE: f32 = 0.03;

fn update_camera(windows: Res<Windows>, mut query: Query<&mut Transform, With<Camera>>) {
    // Games typically only have one window (the primary window).
    // For multi-window applications, you need to use a specific window ID here.
    let window = windows.get_primary().unwrap();

    if let Some(_position) = window.cursor_position() {
        // cursor is inside the window, position given
        let window_size: Vec2 = Vec2::new(window.width(), window.height());

        let range: Vec2 = Vec2::new(RANGE_VALUE, RANGE_VALUE);
        let target: Vec2 = ((_position / window_size) * range) - (range / 2.0);
        let mut _transform = query.single_mut();

        let base_rotation = Transform::from_xyz(CAMERA_X, CAMERA_Y, CAMERA_Z)
            .looking_at(Vec3::new(0.0, 0.8, 0.1), Vec3::Y)
            .rotation;

        _transform.rotation = Quat::from_xyzw(
            base_rotation.x + target.y,
            base_rotation.y - target.x,
            base_rotation.z,
            base_rotation.w,
        );
    } else {
        // cursor is not inside the window
    }
}

pub struct CameraPlugin;

impl Plugin for CameraPlugin {
    fn build(&self, app: &mut App) {
        // systems to run once at startup:
        app.add_startup_system(setup_camera)
            // systems to run each frame:
            .add_system(update_camera);
    }
}
