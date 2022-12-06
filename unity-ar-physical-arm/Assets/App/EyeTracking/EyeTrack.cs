using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Input
{
    public class EyeTrack : InputSystemGlobalHandlerListener, IMixedRealityFocusHandler
    {
        /// <inheritdoc/>
        protected override void RegisterHandlers()
        {
            CoreServices.InputSystem?.RegisterHandler<IMixedRealityPointerHandler>(this);
            CoreServices.InputSystem?.RegisterHandler<IMixedRealitySpeechHandler>(this);
        }
        /// <inheritdoc/>
        protected override void UnregisterHandlers()
        {
            CoreServices.InputSystem?.UnregisterHandler<IMixedRealityPointerHandler>(this);
            CoreServices.InputSystem?.UnregisterHandler<IMixedRealitySpeechHandler>(this);
        }
        void IMixedRealityFocusHandler.OnFocusEnter(FocusEventData eventData)
        {
            Experiment.ObjLookedAt(gameObject);
        }

        void IMixedRealityFocusHandler.OnFocusExit(FocusEventData eventData)
        {
            Experiment.ObjLookedAway(gameObject);
        }
    }
}