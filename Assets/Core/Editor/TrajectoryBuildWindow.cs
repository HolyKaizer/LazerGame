using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace Core.Editor
{
    public class TrajectoryBuildWindow : OdinEditorWindow
    {
        [HideIf("@this._editingMode.Enabled")]
        [Toggle("Enabled")]
        [SerializeField] private CreationMode _creationMode = new CreationMode();
        [HideIf("@this._creationMode.Enabled")]
        [Toggle("Enabled")]
        [SerializeField] private EditingMode _editingMode = new EditingMode();
        
        public static void ShowWindow()
        {
            GetWindow(typeof(TrajectoryBuildWindow));
        }
        
        protected override void OnGUI()
        {
            base.OnGUI();
            _creationMode.OnGUI();
        }

        private void OnBecameInvisible()
        {
            _creationMode.OnBecameInvisible();
        }

        private void OnDisable()
        {
            _creationMode.OnDisable();
        }

        private void OnBecameVisible()
        {
            _creationMode.OnBecameVisible();
        }
    }
}