using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace Core.Editor
{
    public class TrajectoryBuildWindow : OdinEditorWindow
    {
        [HideIf("@this._editingMode.Enabled")]
        [Toggle("Enabled")]
        [SerializeField] private CreationTrajectoryBuilderMode _creationMode = new CreationTrajectoryBuilderMode();
        [HideIf("@this._creationMode.Enabled")]
        [Toggle("Enabled")]
        [SerializeField] private EditingTrajectoryBuilderMode _editingMode = new EditingTrajectoryBuilderMode();
        
        public static void ShowWindow()
        {
            GetWindow(typeof(TrajectoryBuildWindow));
        }
        
        protected override void OnGUI()
        {
            base.OnGUI();
            _creationMode.OnGUI();
            _editingMode.OnGUI();
        }

        private void OnBecameInvisible()
        {
            _creationMode.OnBecameInvisible();
            _editingMode.OnBecameInvisible();
        }

        private void OnDisable()
        {
            _creationMode.OnDisable();
            _editingMode.OnDisable();
        }

        private void OnBecameVisible()
        {
            _creationMode.OnBecameVisible();
            _editingMode.OnBecameVisible();
        }
    }
}