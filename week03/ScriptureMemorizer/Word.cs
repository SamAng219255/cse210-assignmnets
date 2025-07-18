using System.Globalization;

class Word {
	private string _text;
	private bool _isHidden;
	private int _strLength;

	public Word(string text) {
		_text = text;
		_isHidden = false;
		_strLength = new StringInfo(text).LengthInTextElements;
	}

	public string GetDisplayText() {
		if(_isHidden) {
			return new string('_', _strLength);
		}
		else {
			return _text;
		}
	}

	public void Hide() {
		_isHidden = true;
	}

	public void Show() {
		_isHidden = false;
	}

	public bool isHidden() {
		return _isHidden;
	}
}