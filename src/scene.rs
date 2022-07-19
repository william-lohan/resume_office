use bevy::{prelude::*, scene::InstanceId};

const RES0_INDEX: usize = 0;
const RES1_INDEX: usize = 1;
const LAPTOP_INDEX: usize = 1;

// Resource to hold the scene `instance_id` until it is loaded
#[derive(Default)]
struct SceneInstance(Option<InstanceId>);

fn spawn_scene(
    mut commands: Commands,
    asset_server: Res<AssetServer>,
    mut scene_spawner: ResMut<SceneSpawner>,
    mut scene_instance: ResMut<SceneInstance>,
) {
    // note that we have to include the `Scene0` label
    let my_gltf: Handle<Scene> = asset_server.load("resume_office.gltf#Scene0");

    let instance_id = scene_spawner.spawn(my_gltf);
    scene_instance.0 = Some(instance_id);

    commands.spawn_bundle(PointLightBundle {
        transform: Transform::from_xyz(3.186, 3.641, 0.67),
        ..default()
    });

    commands.spawn_bundle(PointLightBundle {
        transform: Transform::from_xyz(-2.368, 2.431, 2.271),
        ..default()
    });
}

// This system will wait for the scene to be ready, and then tag entities from
// the scene with `EntityInMyScene`. All entities from the second scene will be
// tagged
fn scene_update(
    scene_spawner: Res<SceneSpawner>,
    scene_instance: Res<SceneInstance>,
    mut done: Local<bool>,
) {
    if !*done {
        if let Some(instance_id) = scene_instance.0 {
            if let Some(entity_iter) = scene_spawner.iter_instance_entities(instance_id) {
                for (i, entity) in entity_iter.enumerate() {
                    if i == RES0_INDEX {
                        // TODO
                    }
                    if i == RES1_INDEX {
                        // TODO
                    }
                    if i == LAPTOP_INDEX {
                        // TODO
                    }
                }

                *done = true;
            }
        }
    }
}

pub struct ScenePlugin;

impl Plugin for ScenePlugin {
    fn build(&self, app: &mut App) {
        // resources:
        app.init_resource::<SceneInstance>()
            // systems to run once at startup:
            .add_startup_system(spawn_scene)
            // systems to run each frame:
            .add_system(scene_update);
    }
}
